     class bullet
            {
                public bool needToBeAdded;
                public string name;
                public bullet(string ex_name, bool ex_add) {
                    needToBeAdded = ex_add;
                    name = ex_name;
                }
            }
    
    ...
    
                int bullet = 1;
                StringBuilder Assembler = new StringBuilder();
                List<bullet> myList = new List<bullet>();
    
                //THIS NULL IS INTENTIONAL
                myList.Add(null);
    
                myList.Add(new bullet("Oranges",true));
                myList.Add(new bullet("Banana", true));
                myList.Add(new bullet("This is a Comment and I do not want to add a bullet to it.", false));
    
                foreach (bullet item in myList)            
                    if (item != null&&item.needToBeAdded)                
                        Assembler.AppendLine("(" + bullet++ + ") " + item.name);
                Console.Write(Assembler.ToString());
                Console.ReadKey();
