    int snappingMargin = 25;
    if (Math.Abs(SystemParameters.WorkArea.Left - newLeft) < snappingMargin)
        newLeft = SystemParameters.WorkArea.Left;
    else if (Math.Abs(newLeft + this.ActualWidth - SystemParameters.WorkArea.Left - SystemParameters.WorkArea.Width) < snappingMargin)
        newLeft = SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - this.ActualWidth;
    if (Math.Abs(SystemParameters.WorkArea.Top - newTop) < snappingMargin)
        newTop = SystemParameters.WorkArea.Top;
    else if (Math.Abs(newTop + this.ActualHeight - SystemParameters.WorkArea.Top - SystemParameters.WorkArea.Height) < snappingMargin)
        newTop = SystemParameters.WorkArea.Top + SystemParameters.WorkArea.Height - this.ActualHeight;
