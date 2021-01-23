    /// <summary>
    /// For use with Windows Forms
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="controlCollection"></param>
    /// <param name="resultCollection"></param>
    public static void GetControlsRecursiveWin<T>(System.Windows.Forms.Control.ControlCollection controlCollection, List<T> resultCollection) where T : System.Windows.Forms.Control
    {
        foreach (System.Windows.Forms.Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);
                if (control.HasChildren)
                    GetControlsRecursiveWin(control.Controls, resultCollection);
            }
    }
