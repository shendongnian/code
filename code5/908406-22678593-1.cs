    using System.Xml.Linq;
    
    string xml = @"<?xml version='1.0' encoding='utf-8'?>
    <root>
      <key value='22.wav'>
        <Index>1</Index>
      </key>
      <key value='22.wav'>
        <Index>0</Index>
      </key>
      <key value='22.wav'>
        <Index>7</Index>
      </key>
      <key value='22.wav'>
        <Index>13</Index>
      </key>
    </root>";
    // Convert the string to XLinq
    var xe = XElement.Parse(xml);
    // Create a dictionary with Linq extension
    // Use int ("Index") as the key
    // Use string (key[@value]) as the value
    var dict = xe.Descendants("Index")
                 .ToDictionary(k => int.Parse(k.Value),
                               v => v.Parent.Attribute("value").Value);
    
    // Results --
    // Key    Value
    // ------ ----------
    // 1      22.wav
    // 0      22.wav
    // 7      22.wav
    // 13     22.wav
