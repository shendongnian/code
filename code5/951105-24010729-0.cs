    using Microsoft.VisualBasic.CompilerServices;
    using MSForms = Microsoft.Vbe.Interop.Forms;
    
    // ...
    
    // set name of button
    var cmdButton = (Excel.Shape) ws.Shapes.Item (1);
    cmdButton.Name = "btnClick";
    
    // ...
    
    // get button by name
    var cb = (MSForms.CommandButton) NewLateBinding.LateGet (
       ws, // Worksheet object
       null, "btnClick", new object [0], null, null, null
    );
    
    // register event handler
    cb.Click += click;
    
    // ...
    
    // event handler
    void click () {
       // ...
    }
