                //declare it as class member
                int MouseClicksCount = 0;
                bool isfound=false;
                //event handler
                private void Form1_MouseClick(object sender, MouseEventArgs e)
                {       
                    isfound=false;
                    foreach(Region r in regionList)
                    {
                    if (r.IsVisible(e.X, e.Y))
                    {
                        isfound=true;
                        break;
                    }
                    }
                    if (isfound)
                        MouseClicksCount++;
                }
