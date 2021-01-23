    using System;
    namespace Foo
    {
        internal class Car : IVehicle
        {
            private Car(String make)
            {
                this.Make = make;
            }
            private String Make { get; set; }
            
            private CarEngine Engine { get; set; }
            private void TurnIgnition()
            {
                this.Engine.EngageStarterMotor();
            }
            private class CarEngine
            {
                private Int32 Cylinders { get; set; }
                
                private void EngageStarterMotor()
                {
                }
            }
            private delegate void SomeOtherAction(Int32 x);
            public static Boolean operator==(Car left, Car right) { return false; }
            public static Boolean operator!=(Car left, Car right) { return true; }
        }
        
        internal struct Bicycle : IVehicle
        {
            private String Model { get; set; }
        }
        internal interface IVehicle
        {
            public void Move(); // this is a compile error as interface members cannot have access modifiers
        }
        internal delegate void SomeAction(Int32 x);
    }
