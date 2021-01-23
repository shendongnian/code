    private void CreateCsvSchemaFile()
        {
            using (FileStream fs = new FileStream(Path.GetDirectoryName(FilePath) + "\\schema.ini", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("[" + Path.GetFileName(FilePath) + "]");
                    sw.WriteLine("ColNameHeader=True");
                    sw.WriteLine("Format=Delimited(;)");
                    sw.WriteLine("DateTimeFormat=yyyy-MM-dd");
                    sw.WriteLine("CharacterSet=ANSI");
                    sw.WriteLine("Col1=\"Operating Unit Organization Name\" Text Width 255");
                    sw.WriteLine("Col2=\"Year\" Long");
                    sw.WriteLine("Col3=\"Sales Rep Name\" Text Width 255");
                    sw.WriteLine("Col4=\"Date\" DateTime");
                    sw.WriteLine("Col5=\"Week\" Text Width 255");
                    sw.WriteLine("Col6=\"Product Number\" Text Width 255");
                    sw.WriteLine("Col7=\"Account Name\" Text Width 255");
                    sw.WriteLine("Col8=\"Customer Number\" Text Width 255");
                    sw.WriteLine("Col9=\"Corporate Brand\" Text Width 255");
                    sw.WriteLine("Col10=\"Brand\" Text Width 255");
                    sw.WriteLine("Col11=\"Ordered Quantity\" Long");
                    sw.WriteLine("Col12=\"Amount\" Currency");
                    sw.Close();
                    sw.Dispose();
                }
                fs.Close();
                fs.Dispose();
            }
        }
