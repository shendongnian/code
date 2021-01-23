    using System;
    using Microsoft.SPOT;
    using Microsoft.SPOT.Hardware;
    using SecretLabs.NETMF.Hardware;
    using SecretLabs.NETMF.Hardware.Netduino;
    
    namespace Servo_API
    {
        public class Servo : IDisposable
        {
            /// <summary>
            /// PWM handle
            /// </summary>
            private PWM servo;
    
            /// <summary>
            /// Timings range
            /// </summary>
            private int[] range = new int[2];
    
            /// <summary>
            /// Set servo inversion
            /// </summary>
            public bool inverted = false;
    
            /// <summary>
            /// Create the PWM Channel, set it low and configure timings
            /// </summary>
            /// <param name="pin"></param>
            public Servo(Cpu.PWMChannel channelPin)
            {
                // Init the PWM pin
               // servo = new PWM((Cpu.PWMChannel)channelPin, 20000, 1500, PWM.ScaleFactor.Microseconds, false);
                servo = new PWM(PWMChannels.PWM_PIN_D5, 20000, 1500, Microsoft.SPOT.Hardware.PWM.ScaleFactor.Microseconds, false);
                servo.Period = 20000;
         
                // Typical settings
                range[0] = 1000;
                range[1] = 2000;
            }
    
            public void Dispose()
            {
                disengage();
                servo.Dispose();
            }
    
            /// <summary>
            /// Allow the user to set cutom timings
            /// </summary>
            /// <param name="fullLeft"></param>
            /// <param name="fullRight"></param>
            public void setRange(int fullLeft, int fullRight)
            {
                range[1] = fullLeft;
                range[0] = fullRight;
            }
    
            /// <summary>
            /// Disengage the servo. 
            /// The servo motor will stop trying to maintain an angle
            /// </summary>
            public void disengage()
            {
                // See what the Netduino team say about this... 
                servo.DutyCycle = 0; //SetDutyCycle(0);
            }
    
            /// <summary>
            /// Set the servo degree
            /// </summary>
            public double Degree
            {
                set
                {
                    /// Range checks
                    if (value > 180)
                        value = 180;
    
                    if (value < 0)
                        value = 0;
    
                    // Are we inverted?
                    if (inverted)
                        value = 180 - value;
    
                    // Set the pulse
                    //servo.SetPulse(20000, (uint)map((long)value, 0, 180, range[0], range[1]));
                    servo.Duration = (uint)map((long)value, 0, 180, range[0], range[1]);
                    servo.Start();
                }
            }
    
        
            private long map(long x, long in_min, long in_max, long out_min, long out_max)
            {
                return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
            }
        }
    }
