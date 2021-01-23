     static void inline_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Run Sender = sender as Run;
            TextPointer tp0 = Sender.ElementStart;
            TextPointer tp1 = Sender.ElementEnd;
            Rect r0 = tp0.GetCharacterRect(LogicalDirection.Forward);
            Rect r1 = tp1.GetCharacterRect(LogicalDirection.Backward);
            if (r1.Top != r0.Top)
            {
                /* this inline element spans two physical rows */
                Rect StartRect0 = r0;
                Rect EndRect0 = tp1.GetLineStartPosition(0).GetCharacterRect(LogicalDirection.Backward);
                StartRect0.Union(EndRect0);
                Rect StartRect1 = new Rect(0, r1.Top, 0, r1.Height);
                Rect EndRect1 = r1;
                StartRect1.Union(EndRect1);
            }
            else
            {
                Rect StartRect0 = tp0.GetCharacterRect(LogicalDirection.Forward);
                Rect EndRect0 = tp1.GetCharacterRect(LogicalDirection.Backward);
                StartRect0.Union(EndRect0);
            }
        }
