    var xaml = "<Style TargetType=\"{x:Type DataGridCell}\"><Setter Property=\"VerticalContentAlignment\" Value=\"Center\"/>" +
               "<Setter Property=\"HorizontalContentAlignment\" Value=\"Center\"/>" +
               "<Setter Property=\"Template\">" +
               "<Setter.Value><ControlTemplate TargetType=\"DataGridCell\">" +
               "<Border BorderBrush=\"{TemplateBinding BorderBrush}\" BorderThickness=\"{TemplateBinding BorderThickness}\" Background=\"{TemplateBinding Background}\" SnapsToDevicePixels=\"True\">" +
               "<ContentPresenter SnapsToDevicePixels=\"{TemplateBinding SnapsToDevicePixels}\" VerticalAlignment=\"{TemplateBinding VerticalContentAlignment}\" HorizontalAlignment=\"{TemplateBinding HorizontalContentAlignment}\"/>" +
               "</Border></ControlTemplate></Setter.Value></Setter></Style>";
    var parserContext = new System.Windows.Markup.ParserContext();          
    parserContext.XmlnsDictionary
                 .Add("","http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    parserContext.XmlnsDictionary
                 .Add("x","http://schemas.microsoft.com/winfx/2006/xaml");            
    yourDataGrid.CellStyle = 
                 (Style)System.Windows.Markup.XamlReader.Parse(xaml,parserContext); 
  
