    Expression<Func<Product, bool>> exp = (x) => (x.Id > 5 && x.Warranty != false);
    string expBody = ((LambdaExpression)exp).Body.ToString(); 
    // Gives: ((x.Id > 5) AndAlso (x.Warranty != False))
    var paramName = exp.Parameters[0].Name;
    var paramTypeName = exp.Parameters[0].Type.Name;
    // You could easily add "OrElse" and others...
    expBody = expBody.Replace(paramName + ".", paramTypeName + ".")
                 .Replace("AndAlso", "&&");
    Console.WriteLine(expBody);
    // Output: ((Product.Id > 5) && (Product.Warranty != False))
