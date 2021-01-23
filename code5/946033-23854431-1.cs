    private void SetUiData()
    {
        double NewTop = Convert.ToDouble(NewPlaneTop - PlaneFlight);
        Dispatcher.BeginInvoke(() =>
            PlaneObj.Margin = new Thickness(newPlaneLeft, NewTop, newPlaneRight, newPlaneBottom);
        }
    }
