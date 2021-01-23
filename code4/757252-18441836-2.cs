    using lib2;
    using System;
    using System.IO;
    using System.Reflection;
        
        namespace ConsoleApplication1
        {
        	class Program
        	{
        		static void Main ( string [ ] args )
        		{
        			var fileInfo = new FileInfo ( @".\lib1.dll" );
        			var assembly = Assembly.LoadFile ( fileInfo.FullName );
        			var obj = assembly.CreateInstance ( "lib1.Class1" ) as IInterface1;
        			if ( obj != null ) obj.MethodOne ( );
        			Console.ReadLine ( );
        		}
        	}
        }
