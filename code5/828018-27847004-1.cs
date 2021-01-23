    #!/usr/bin/csexec -r:System.Windows.Forms.dll -r:System.Drawing.dll                                                                   
    using System;                                                                                                                                
    using System.Drawing;                                                                                                                        
    using System.Windows.Forms;                                                                                                                  
    public class Program                                                                                                                         
    {                                                                                                                                            
        public static void Main(string[] args)                                                                                                     
        {                                                                                                                                          
            Console.WriteLine("Hello Console");                                                                                                      
            Console.WriteLine("Arguments: " + string.Join(", ", args));                                                                              
            MessageBox.Show("Hello GUI");                                                                                                            
        }                                                                                                                                          
    }                                                                                                                                            
