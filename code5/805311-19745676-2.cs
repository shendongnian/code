    Func<string, double> func = str => InputValidators.InputConverter(str);
    
    Task<double> t1 = Task<double>.Factory.StartNew(() => func(txtA.text));
    Task<double> t2 = Task<double>.Factory.StartNew(() => func(txtB.text));
    Task<double> t3 = Task<double>.Factory.StartNew(() => func(txtC.text));
    double a = t1.Result;
    double b = t2.Result;
    double c = t3.Result;
