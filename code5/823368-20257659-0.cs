    foreach (string  line in lines)
                 {
                   if (first)
                    {
                        if (line != "CTF") { break; }    // i think the problem is here.
                            
                    }
                    else
                    {
    
                        tabs = line.Split('\t');
                        ID = int.Parse(tabs[0]);
                        X = int.Parse(tabs[1]);
                        Y = int.Parse(tabs[2]);
                        H = int.Parse(tabs[3]);
                        W = int.Parse(tabs[4]);
                        Text = tabs[5];
                        ItemTypes types = (ItemTypes)int.Parse(tabs[6]);
    
                            Items.Add(new FormItem());
                            Items[i].Id = ID;
                            Items[i].X = X;
                            Items[i].Y = Y;
                            Items[i].Height = H;
                            Items[i].Width = W;
                            Items[i].Text = Text;
                            Items[i].Type = types;
                           i++;
    
    
                    }
        first = false;
    }
