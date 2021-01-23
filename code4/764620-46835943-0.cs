    using MSForms = Microsoft.Vbe.Interop.Forms;
    using System.Windows.Forms;
    ...
    
    // insert object shape
    Excel.Shape cbo = ws.Shapes.AddOLEObject("Forms.ComboBox.1", Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, 20, 1, 100, 20);
    cbo.Name = cboName;
    
    // bind it and wire it up
    MSForms.ComboBox comboBox = (Microsoft.Vbe.Interop.Forms.ComboBox)Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(ws, null, cboName, new object[0], null, null, null);
    comboBox.FontSize = 10;
    comboBox.FontBold = true;
    comboBox.Change += new MSForms.MdcComboEvents_ChangeEventHandler(comboBox_Changed);
    
    // samle data
    comboBox.AddItem("Stackoverflow");
    comboBox.AddItem("Cool devs");
    ...
    private void comboBox_Changed()
    {
        System.Windows.Forms.MessageBox.Show("Selectiong Changed!");
    }
