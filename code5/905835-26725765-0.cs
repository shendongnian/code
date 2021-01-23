    using SharpDX.Toolkit.Graphics;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace tktex
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage: tktex <texture file>");
                    return;
                }
                try
                {
                    string fileName = args[0];
                    string newName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".tktx");
                    var image = Image.Load(fileName);
                    image.Save(newName, ImageFileType.Tktx);
                    Console.WriteLine(fileName + " => " + newName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
