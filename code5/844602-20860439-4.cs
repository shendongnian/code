    namespace EmitTest
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Reflection.Emit;
        using System.Reflection;
    
        public class TestPropertyBuilde
        {
            TypeBuilder tb;
            FieldBuilder countFB;
    
            // The code in this class generates the code in the following comment:
            /*
            namespace EmitTest
            {
    	        public class TestType
    	        {
    		        private int count;
    		        public int TestProperty
    		        {
    			        get
    			        {
    				        return this.count;
    			        }
    		        }
    		        public TestType()
    		        {
    			        this.count = 1;
    		        }
    	        }
            }
            */
    
            public void Build()
            {
                AssemblyName name = new AssemblyName( "GeneratedAssm" );
    
                AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly( 
                    name, 
                    AssemblyBuilderAccess.RunAndSave, 
                    @"C:\Users\antiduh\Desktop\EmitTest" );
    
                ModuleBuilder mb = assembly.DefineDynamicModule( name.Name, name.Name + ".dll" );
    
                this.tb = mb.DefineType( "EmitTest.TestType", TypeAttributes.Public );
    
                CreateVariable();
    
                CreateConstructor();
    
                CreateProperty( "TestProperty", typeof( int ) );
    
                Type dummy = tb.CreateType();
                assembly.Save( "GeneratedAssm.dll" );
            }
    
            private void CreateVariable()
            {
                this.countFB = tb.DefineField( "count", typeof( int ), FieldAttributes.Private );
            }
    
            private void CreateConstructor()
            {
                ConstructorBuilder ctor0 = tb.DefineConstructor(
                    MethodAttributes.Public,
                    CallingConventions.Standard,
                    Type.EmptyTypes );
    
    
                var gen = ctor0.GetILGenerator();
    
                gen.Emit( OpCodes.Ldarg_0 );
                gen.Emit( OpCodes.Call, typeof( object ).GetConstructor( Type.EmptyTypes ) );
    
                gen.Emit( OpCodes.Ldarg_0 );
                gen.Emit( OpCodes.Ldc_I4_1 );
                gen.Emit( OpCodes.Stfld, countFB);
    
                gen.Emit( OpCodes.Ret );
            }
            
            private void CreateProperty(string propertyName, Type propType )
            {
    
                var propertyBuilder = tb.DefineProperty( 
                    propertyName, 
                    PropertyAttributes.None,
                    CallingConventions.HasThis, 
                    propType, 
                    Type.EmptyTypes );
    
                var methodBuilder = tb.DefineMethod( 
                    "get_" + propertyName,
                    MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                    propType,
                    Type.EmptyTypes );
    
                var methodGenerator = methodBuilder.GetILGenerator();
                
                methodGenerator.Emit( OpCodes.Ldarg_0 );
                methodGenerator.Emit( OpCodes.Ldfld, countFB );
                methodGenerator.Emit( OpCodes.Ret );
            propertyBuilder.SetGetMethod( methodBuilder );
        }
    }
}
