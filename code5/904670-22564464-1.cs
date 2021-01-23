    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
        Form1 form = new Form1();
        String[] arguments = Environment.GetCommandLineArgs();
        if (arguments.Count() > 1)
        {
            Int16 valueArgument = Int16.Parse(arguments[1]);
            switch(valueArgument)
            {
                case 1 :
                    form.Process1();
                    break;
                case 2:
                     form.Process2();
                    break;
                case 3:
                    form.Process3();
                    break;
                case 4:
                    form.Process4();
                    break;
                case 5:
                    form.Process5();
                    break;
                case 6:
                    form.Process6();
                    break;
                case 7:
                    form.Process7();
                    break;
                case 8:
                    form.Process8();
                    break;
            }
        }
        else
        {
            form.ShowDialog();
        }
    }
