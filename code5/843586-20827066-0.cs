     List<Tuple<string, string>> MyList = new List<Tuple<string, string>>(); 
     if (File.Exists(@"filename.dat"))
            {
                //LOAD
                Console.WriteLine("Load filename.dat...");
                FileStream inStr = new FileStream(@"filename.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                MyList = bf.Deserialize(inStr) as List<Tuple<string, string>>;
            }
            else {
                //
                // Do here the list building/ Make the List<Tuple<string, string>> MyList
                //
   
                //SAVE
                FileStream stream = new FileStream(@"filename.dat", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, MyList);
                stream.Close();            
            }
