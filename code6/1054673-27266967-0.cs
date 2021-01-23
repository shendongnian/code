    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace Test
    {
    public unsafe class Program
    {
     public delegate void MemCpyFunction(void *des, void *src, uint bytes);
    
     private static readonly MemCpyFunction MemCpy;
    
     static Program()
     {
         var dynamicMethod = new DynamicMethod
         (
             "MemCpy",
             typeof(void),
             new [] { typeof(void *), typeof(void *), typeof(uint) },
             typeof(Program)
         );
    
         var ilGenerator = dynamicMethod.GetILGenerator();
    
         ilGenerator.Emit(OpCodes.Ldarg_0);
         ilGenerator.Emit(OpCodes.Ldarg_1);
         ilGenerator.Emit(OpCodes.Ldarg_2);
    
         ilGenerator.Emit(OpCodes.Cpblk);
         ilGenerator.Emit(OpCodes.Ret);
    
         MemCpy = (MemCpyFunction)dynamicMethod
                     .CreateDelegate(typeof(MemCpyFunction));
     }
    
     static void Main(string[] args)
     {
         var point1 = new Point
                      {
                          X = 10,
                          Y = 20
                      };
    
         var point2 = new Point();
    
         MemCpy(&point2, &point1, (uint)sizeof(Point));
     }
    }
    }
