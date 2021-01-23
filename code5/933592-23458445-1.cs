    // mapping for property:
    // public virtual IList<Image> Images {get; set;}
    Bag(x => x.Images // reference
           , b => { } // bag properties mapper
           , v => v.Component(ImageMap.Mapping()) // here we pass the <composite-element>
       ); 
