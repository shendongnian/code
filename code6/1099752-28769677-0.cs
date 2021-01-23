     var slider = new Slider();
     slider.Template = (ControlTemplate)XamlReader.Parse(template);
     slider.ApplyTemplate();
     var track = (Track)slider.Template.FindName("PART_Track", slider);
     var thumb = (Thumb)(track.FindName("Thumb") );
     thumb.ApplyTemplate(); // key here
     var rect = (Rectangle)thumb.Template.FindName("slideRec", thumb);
     rect.Fill = new SolidColorBrush(Colors.Blue);
