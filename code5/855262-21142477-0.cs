     private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                
                string ruta = @"..\wbcimpresion"+destino+".txt";
                //borra si existe
                if (System.IO.File.Exists(ruta))
                    System.IO.File.Delete(ruta);
                 //creo mi archivo
    
                    if (kryptonDataGridView1.Rows.Count > 0)
                    {
                        System.IO.StreamWriter escritor = new System.IO.StreamWriter(ruta);
    
    
                        for (int columna = 0; columna < kryptonDataGridView1.Columns.Count; columna++)
                        {
                            escritor.Write(kryptonDataGridView1.Columns[columna].HeaderText.ToString()+"\t\t");
                        }
    
        
                        for (int fila = 0; fila < kryptonDataGridView1.Rows.Count; fila++)
                        {
                            escritor.WriteLine();
                            System.IO.StringWriter stringescritor = new System.IO.StringWriter();
                            for (int columna = 0; columna < kryptonDataGridView1.Columns.Count; columna++)
                            {
                          
    
                                stringescritor.Write
                                    (
                                   kryptonDataGridView1.Rows [fila].Cells [columna ].Value.ToString ()+"\t"
    
                                    );
    
                            }
    
                            string dato = stringescritor.ToString();
                            
                            if (dato.Length > 120)
                            {
                                int contador1 = 0;
                                while (dato.Length > 120)
                                {
                                    if (contador1 == 0)
                                        escritor.Write(dato.Substring(0, 120));
                                    else
                                    {
                                        escritor.WriteLine();
                                        escritor.Write(dato.Substring(0, 120));
                                    }
                                    dato = dato.Remove(0, 120);
                                    contador1++;
                                }
                                escritor.WriteLine();
                                escritor.Write (dato.Substring (0,dato.Length ));
    
    
                            }
                            else
                            { 
                            escritor.Write (dato.Substring (0,dato.Length ));
                            }
                        }
                        escritor.Flush();
                        escritor.Close();
                        escritor.Dispose();
                    }
                
                
    
                string imprimeme = "";
                System.IO.StreamReader lector = new System.IO.StreamReader (ruta);
                imprimeme = lector.ReadToEnd();
                
                lector.Close();
                lector.Dispose();
                float leftMargin = e.MarginBounds.Left;
                float rightMargin = e.MarginBounds.Right;
                leftMargin = 40;
                rightMargin = 60;
                printDocument1.DefaultPageSettings.Landscape = true;
                
                e.Graphics.DrawString(imprimeme, new Font("Arial", 11, FontStyle.Regular ), Brushes.Black, leftMargin, rightMargin);
                
                
                
                
             
            }
