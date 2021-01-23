    using MSForms = Microsoft.Vbe.Interop.Forms;
    using Microsoft.VisualBasic.CompilerServices;
    ...
    MSForms.CommandButton CommandButton1 = (MSForms.CommandButton)NewLateBinding.LateGet(Globals.ThisWorkbook.Worksheets(1), null, "CommandButton1", new object[0], null, null, null);                
    CommandButton1.Click += new Microsoft.Vbe.Interop.Forms.CommandButtonEvents_ClickEventHandler(CommandButton1_Click);
