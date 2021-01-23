    using System;
    namespace Foo
    {
        class Car : IVehicle
        {
            Car(String make)
            {
                this.Make = make;
            }
            String Make { get; set; }
            
            CarEngine Engine { get; set; }
            void TurnIgnition()
            {
                this.Engine.EngageStarterMotor();
            }
            class CarEngine
            {
                Int32 Cylinders { get; set; }
                
                void EngageStarterMotor()
                {
                }
            }
            delegate void SomeOtherAction(Int32 x);
            // The operator overloads won't compile as they must be public.
            static Boolean operator==(Car left, Car right) { return false; }
            static Boolean operator!=(Car left, Car right) { return true; }
        }
        
        struct Bicycle : IVehicle
        {
            String Model { get; set; }
        }
        interface IVehicle
        {
            void Move();
        }
        delegate void SomeAction(Int32 x);
    }
