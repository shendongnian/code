    using System;
    using System.IO;
    using System.Windows.Forms;
    using SoundForge;
    public class EntryPoint {
        public void Begin(IScriptableApp app) {
           string strFile1   = GETARG("file1", "");
           string strFile2   = GETARG("file2", "");
           string strOutFile = GETARG("outfile", "");
        if ("" == strFile1 || "" == strFile2 || "" == strOutFile)
        {
           MessageBox.Show("useage\nfile1=path\\filename&file2=path\\filename&outfile=path\\filename", "invald arguments");
          return;
        }
    ISfFileHost fhOne = app.OpenFile(strFile1, true, true);
    if (null == fhOne)
       return;
    ISfFileHost fhTwo = app.OpenFile(strFile2, true, true);
    if (null == fhTwo)
    {
       fhOne.Close(CloseOptions.DiscardChanges);
       return;
    } 
    ISfFileHost fhOut = app.NewFile(fhOne.DataFormat, false);
    fhOut.ReplaceAudio(new SfAudioSelection(0,0), fhOne, new SfAudioSelection(fhOne));
    fhOut.DoEffect("Invert/Flip", 0, new SfAudioSelection(fhOut), EffectOptions.EffectOnly);
    fhOut.WaitForDoneOrCancel();
    fhOut.MixAudio(new SfAudioSelection(fhOut), 1.0, 1.0, fhTwo, new SfAudioSelection(fhTwo));
    fhOut.WaitForDoneOrCancel();
    fhOut.SaveAs(strOutFile, fhOne.SaveFormat.Guid, "Default Template", RenderOptions.RenderOnly);
    fhOut.WaitForDoneOrCancel();
   
    fhOne.Close(CloseOptions.DiscardChanges);
    fhTwo.Close(CloseOptions.DiscardChanges);
    fhOut.Close(CloseOptions.DiscardChanges);
   
    // Close Sound Forge.
    System.Diagnostics.Process curr = System.Diagnostics.Process.GetCurrentProcess();
     curr.CloseMainWindow();
     } 
    public void FromSoundForge(IScriptableApp app) {
    ForgeApp = app; //execution begins here
    app.SetStatusText(String.Format("Script '{0}' is running.", Script.Name));
    Begin(app);
    app.SetStatusText(String.Format("Script '{0}' is done.", Script.Name));
    }
    public static IScriptableApp ForgeApp = null;
    public static void DPF(string sz) { ForgeApp.OutputText(sz); }
    public static void DPF(string fmt, object o) {      ForgeApp.OutputText(String.Format(fmt,o));
    }
    public static void DPF(string fmt, object o, object o2) {      ForgeApp.OutputText(String.Format(fmt,o,o2));
     }
    public static void DPF(string fmt, object o, object o2, object o3) {      ForgeApp.OutputText(String.Format(fmt,o,o2,o3)); 
     }
     public static string GETARG(string k, string d) { string val = Script.Args.ValueOf(k);     if (val == null || val.Length == 0) val = d; return val; 
     }
    public static int    GETARG(string k, int d) { string s = Script.Args.ValueOf(k); if (s == null || s.Length == 0) return d; else return Script.Args.AsInt(k); }
    public static bool   GETARG(string k, bool d) { string s = Script.Args.ValueOf(k); if (s == null || s.Length == 0) return d; else return Script.Args.AsBool(k); }
    } //EntryPoint
