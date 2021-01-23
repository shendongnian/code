    //creating a new VBA module (must be a reference to Microsoft.Vbe.Interop)
    Microsoft.Vbe.Interop.VBComponent vbaModule = 
         docComp.VBProject.VBComponents.Add(
         Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule); 
    //insert VBA macro code
    vbaModule.CodeModule.AddFromString(string_with_your_vba_code);
    //run the macro
    Microsoft.Office.Interop.Word.Application.GetType().InvokeMember("Run", 
         BindingFlags.Default | BindingFlags.InvokeMethod,
         null,
         Microsoft.Office.Interop.Word.Application,
         new Object[] { "name_of_your_main_sub" });
