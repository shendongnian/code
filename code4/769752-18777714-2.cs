    class onetwo
    {
        public virtual string ToPrintableString()
        {
            return string.Join(", ", 
                this.GetType()
                    .GetFields()
                    .Select(p => p.Name + ": " + p.GetValue(this));
        }
    } 
    ...
    foreach (onetwo e in listC1)
    {
        Console.WriteLine(e.ToPrintableString());
    }
