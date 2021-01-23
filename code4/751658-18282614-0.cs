    public bool IsRed {get;set;}
    
    
    void Ellipse1_Tapped(object sender, etcetera)
    {
        Ellipse1.Fill = IsRed ? Brushes.Red : Brushes.White;
        IsRed = !IsRed;
    }
