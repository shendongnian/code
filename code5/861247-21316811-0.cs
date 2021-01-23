    <ObjectDataProvider x:Key="EnumerableRange"
                        xmlns:sys="clr-namespace:System;assembly=mscorlib"
                        xmlns:linq="clr-namespace:System.Linq;assembly=System.Core"
                        ObjectType="{x:Type linq:Enumerable}" MethodName="Range">
         <ObjectDataProvider.MethodParameters>
             <sys:Int32>1</sys:Int32>
             <sys:Int32>100</sys:Int32>
         </ObjectDataProvider.MethodParameters>
     </ObjectDataProvider>
