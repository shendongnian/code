    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using SoundForge;
    public class EntryPoint
    {
        public void Begin(IScriptableApp app)
        {
        string strOutFile = GETARG("outfile", "path to save file at");
        if ("" == strOutFile)
        {
            MessageBox.Show("invald output path");
            return;
        }
        OpenFileDialog openFile = new OpenFileDialog();
        openFile.Title = "Open the input file.";
        ////string to hold the path of input file.
        String strFile1 = String.Empty;
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            strFile1 = openFile.FileName.ToString();
        }
        OpenFileDialog openOutputFile = new OpenFileDialog();
        openOutputFile.Title = "Open the output file.";
        ////string to hold the path of output file.
        String strFile2 = String.Empty;
        if (openOutputFile.ShowDialog() == DialogResult.OK)
        {
            strFile2 = openOutputFile.FileName.ToString();
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
        fhOut.ReplaceAudio(new SfAudioSelection(0, 0), fhOne, new SfAudioSelection(fhOne));
        fhOut.DoEffect("Invert/Flip", 0, new SfAudioSelection(fhOut), EffectOptions.EffectOnly);
        fhOut.WaitForDoneOrCancel();
        fhOut.MixAudio(new SfAudioSelection(fhOut), 1.0, 1.0, fhTwo, new SfAudioSelection(fhTwo));
        fhOut.WaitForDoneOrCancel();
        fhOut.SaveAs(strOutFile, fhOne.SaveFormat.Guid, "Default Template", RenderOptions.RenderOnly);
        fhOut.WaitForDoneOrCancel();
        fhOne.Close(CloseOptions.DiscardChanges);
        fhTwo.Close(CloseOptions.DiscardChanges);
        SfAudioStatistics[] stat = new SfAudioStatistics[fhOut.Channels];
        fhOut.UpdateStatistics(SfAudioSelection.All);
        stat[0] = fhOut.GetStatistics(0); 
        stat[1] = fhOut.GetStatistics(1);
        stat[2] = fhOut.GetStatistics(2);
        stat[3] = fhOut.GetStatistics(3);
        stat[4] = fhOut.GetStatistics(4);
        stat[5] = fhOut.GetStatistics(5);
        stat[6] = fhOut.GetStatistics(6);
        stat[7] = fhOut.GetStatistics(7);
        MessageBox.Show(String.Format("Max Sample Value Channel 1 - {0},Channel 2 - {1},Channel 3 - {2},Channel 4 - {3},Channel 5 - {4},Channel 6 - {5},Channel 7 - {6},Channel 8 - {7}", stat[0].MaxValue, stat[1].MaxValue, stat[2].MaxValue, stat[3].MaxValue, stat[4].MaxValue, stat[5].MaxValue, stat[6].MaxValue, stat[7].MaxValue));
        MessageBox.Show(String.Format("Min Sample Value Channel 1 - {0},Channel 2 - {1},Channel 3 - {2},Channel 4 - {3},Channel 5 - {4},Channel 6 - {5}, Channel 7 - {6}, Channel 8 - {7}", stat[0].MinValue, stat[1].MinValue, stat[2].MinValue, stat[3].MinValue, stat[4].MaxValue, stat[5].MinValue, stat[6].MinValue, stat[7].MinValue));
        
        System.Diagnostics.Process curr = System.Diagnostics.Process.GetCurrentProcess();
    }
    public void FromSoundForge(IScriptableApp app)
    {
        ForgeApp = app; //execution begins here
        app.SetStatusText(String.Format("Script '{0}' is running.", Script.Name));
        Begin(app);
        app.SetStatusText(String.Format("Script '{0}' is done.", Script.Name));
    }
    public static IScriptableApp ForgeApp = null;
    public static void DPF(string sz) { ForgeApp.OutputText(sz); }
    public static void DPF(string fmt, object o) { ForgeApp.OutputText(String.Format(fmt, o)); }
    public static void DPF(string fmt, object o, object o2) { ForgeApp.OutputText(String.Format(fmt, o, o2)); }
    public static void DPF(string fmt, object o, object o2, object o3) { ForgeApp.OutputText(String.Format(fmt, o, o2, o3)); }
    public static string GETARG(string k, string d) { string val = Script.Args.ValueOf(k); if (val == null || val.Length == 0) val = d; return val; }
    public static int GETARG(string k, int d) { string s = Script.Args.ValueOf(k); if (s == null || s.Length == 0) return d; else return Script.Args.AsInt(k); }
    public static bool GETARG(string k, bool d) { string s = Script.Args.ValueOf(k); if (s == null || s.Length == 0) return d; else return Script.Args.AsBool(k); }
    } //EntryPoint
