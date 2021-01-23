    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ExplicitInterfaceImplementation
    {
        class Program
        {
            static void Main(string[] args)
            {
                SampleClass sc = new SampleClass();
                var mc = (MainSampleClass)sc;
                IControl ctrl = (IControl)sc;
                ISurface srfc = (ISurface)sc;
                mc.Paint();
                sc.Paint();
                ctrl.Paint();
                srfc.Paint();
                Console.ReadKey();
            }
        }
    
        /// <summary>
        /// Interface 1
        /// </summary>
        interface IControl
        {
            void Paint();
        }
        /// <summary>
        /// Interface 2
        /// </summary>
        interface ISurface
        {
            void Paint();
        }
        /// <summary>
        /// Parent/Main Class 
        /// </summary>
        public class MainSampleClass
        {
            /// <summary>
            /// Parent class Paint Method.
            /// </summary>
            public void Paint()
            {
                Console.WriteLine("Paint method in - Parent MainSampleClass");
            }
        }
        /// <summary>
        /// SampleClass is the Child class inherited from Parent/Main Class and two interfaces
        /// Parent/Main class having a Paint() method and two interfaces having 
        /// Paint() method - each of them having same name but they are not same(different from each other).
        /// </summary>
        public class SampleClass : MainSampleClass,IControl, ISurface
        {
            /// <summary>
            /// new method(Paint()) for Child class, separate from parent class(Paint() method)
            /// </summary>
            public new void Paint()
            {
                Console.WriteLine("Paint method in - Child SampleClass");
            }
       
            /// <summary>
            /// Implementing IControl.Paint() method.
            /// </summary>
            void IControl.Paint()
            {
                System.Console.WriteLine("Paint method in - IControl Interface");
            }
            /// <summary>
            /// Implementing ISurface.Paint() method. 
            /// </summary>
            void ISurface.Paint()
            {
                System.Console.WriteLine("Paint method in - ISurface Interface");
            }
        }
    }
