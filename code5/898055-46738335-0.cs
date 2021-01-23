    using MSForms = Microsoft.Vbe.Interop.Forms;
    using System.Windows.Forms;
    
    ...
    
    Microsoft.Vbe.Interop.Forms.CommandButton CmdBtn;
    
    private void CreateOLEButton()
    {
       Excel.Worksheet ws = Globals.ThisWorkbook.Application.Sheets["MyWorksheet"];
    
       // insert button shape
       Excel.Shape cmdButton = ws.Shapes.AddOLEObject("Forms.CommandButton.1", Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, 500, 5, 100, 60);
       cmdButton.Name = "btnButton";
    
       // bind it and wire it up
       CmdBtn = (Microsoft.Vbe.Interop.Forms.CommandButton)Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(ws, null, "btnButton", new object[0], null, null, null);
       CmdBtn.FontSize = 10;
       CmdBtn.FontBold = true;
       CmdBtn.Caption = "Click me!";
       CmdBtn.Click += new MSForms.CommandButtonEvents_ClickEventHandler(ExecuteCmd_Click);
    }
            
    private void ExecuteCmd_Click()
    {
       MessageBox.Show("Click");
    }
