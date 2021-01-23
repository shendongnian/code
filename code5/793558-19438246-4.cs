                 Console.WriteLine("Strucrures"); 
                    foreach (var str in map.Structures)
                    {
                        Console.WriteLine("Name :{0}  , Attack:{1}  , I:{2}  , J:{3}  ,  Range:{4}  ,  Price:{5}"
                            , str.Name, str.Attack, str.I, str.J, str.Range, str.Price);
                    }
        
        
                    Console.WriteLine("Enemys");
                    foreach (var enmy in map.Enemys)
                    {
                        Console.WriteLine("ID :{0}  , Color:{1}  , HP:{2}  , Orobyte:{3}  ,  Speed:{4} "
                            , enmy.ID, enmy.Color, enmy.HP, enmy.Orobyte, enmy.Speed);
                    }
        
        
                    Console.WriteLine("Waves");
        
                     foreach (var enmy in map.Waves)
                     {
                        Console.WriteLine("Wave ID:{0}", enmy.WaveID);
                        foreach(var gr in enmy.Groups)
                        Console.WriteLine("ID :{0}  , Count:{1} "
                            , gr.ID, gr.Count);
                      }
                
