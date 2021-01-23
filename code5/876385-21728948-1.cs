     private void timer1_Tick(object sender, EventArgs e)
                {
                    AnimateCheckBoxes();
                }
         private static bool  displayed  ;  
                private void AnimateCheckBoxes()
                {
                    for (int i = 0; i < ScrollLabel._lines.Length; i++)
                    {
                        if (ScrollLabel._lines[i].Contains("Test")&&!displayed)
                        {
                            displayed  = true; 
                            MessageBox.Show(ScrollLabel._lines[i]);
                            
                        }
        
                    }
                }
