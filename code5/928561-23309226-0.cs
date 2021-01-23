     private void DrawGraphic(Graphics g) 
    {                    
        g.PageUnit = GraphicsUnit.Millimeter;
        String datn1 = dateiName1, datn2 = dateiName2;
                    char[] Trennzeichen = { '\\' };
                    String[] folders1, folders2;
                    if (vergl.X == 1)
                       folders1 = datn1.Split(Trennzeichen);
                    else
                       folders1 = new String[0];
                    if (vergl.Y == 1)
                       folders2 = datn2.Split(Trennzeichen);
                    else
                       folders2 = new String[0];
                        
                    if (pageSetupDialog1.PageSettings.Landscape == false)
                    {
                      string path_new = "";
                      string path_new2 = "";
                        
                    for (int i = 0; i < folders1.Length; i++)
                    {
                     string path_temp = path_new + folders1[i] + "//";
                     System.Drawing.Size size_path_temp = TextRenderer.MeasureText(path_temp, new Font("Verdana", 8f));  // get size of string path_temp (in pixel)    
                     double size_path_temp_width = Convert.ToDouble(size_path_temp.Width); 
                     double variable = Convert.ToDouble(rightMargin.ToString())*96/25.4d; //96 = dpi Anzahl
                        
                    if (size_path_temp_width < variable)
                     {
                      path_new += folders1[i] + "//";
                     }
                     else
                     {
                      path_new += System.Environment.NewLine + folders1[i] + "//";
                     }
                    }
                    
                for (int i = 0; i < folders2.Length; i++)
                {
                  string path_temp = path_new2 + folders2[i] + "//";
                  System.Drawing.Size size_path_temp = TextRenderer.MeasureText(path_temp, new Font("Verdana", 8f));  // get size of string path_temp (in pixel)    
                  double size_path_temp_width = Convert.ToDouble(size_path_temp.Width);
                  double variable = Convert.ToDouble(rightMargin.ToString()) * 96 / 25.4d; //96 = dpi
                        
             if (size_path_temp_width < variable)
             {
              path_new2 += folders2[i] + "//";
             }
             else
             {
              path_new2 += System.Environment.NewLine + folders2[i] + "//";
             }
            } 
     g.DrawString(path_new, new Font("Verdana", 8f), new SolidBrush(Color.Black), leftMargin, topMargin+10);
     g.DrawString(path_new2, new Font("Verdana", 8f), new SolidBrush(Color.Black), 20, topMargin + 10 + bmp1.Height / 6 + 25);
    } 
      
