    private static void geraNýjaNámsáætlun()
    {
        Console.Write("Hvada nám er þetta?:");
        String nám = Console.ReadLine();
        Console.Write("Villtu gera vikuáætlun? (y/n):");
        string answerYesOrNo = Console.ReadLine();
        answerYesOrNo.Trim();
        string path = @"C:\nám";
        if (answerYesOrNo.ToLower() == "y")
        {
            try
            {
                Console.Write("Enter the name you want for the filename:");
                string some = Console.ReadLine();
                string combined = Path.Combine(path, some + ".txt");
                if (File.Exists(combined))
                {
                    using (TextReader obj2 = new StreamReader(combined))
                    {
                        if (!obj2.ReadLine().Contains("Mon"))
                        {
                            obj2.Close();
                            TextWriter obj = File.AppendText(combined);
                            obj.WriteLine("Mon\t\t\t|Thue\t\t\t|Wedn\t\t\t|Thurs\t\t\t|Friday\t\t\t|Sat\t\t\t|Sun\t\t\t");
                            obj.Close();
                        }
                    }
					using (TextWriter obj = File.AppendText(combined))
					{
							Console.WriteLine("Enginn fyrir monday 3 fyrir thuesday 6 fyrir wednesday 9 fyrir thursday 12 fyrir friday 15 saturday 18 fyrir sunday");
							Console.Write("Enter the number of tabs:");
							int numberOfTabs = Convert.ToInt32(Console.ReadLine());
							Console.Write("Enter the class or lektion:");
							string lektionOrClass = Console.ReadLine();
							obj.WriteLine(Tabs(numberOfTabs) + "" + lektionOrClass);
					}
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
	}
