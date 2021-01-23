            protected override Size MeasureOverride(Size finalSize)
        {
            Size ret = base.MeasureOverride(finalSize);
            Debug.WriteLine(NotificationsControl.DesiredSize);
            if (NotificationsControl.DesiredSize.Height >= Height && Notifications.Count > 0)
            {
                int index;
                if (corner == 0 || corner == 3)
                {
                    index = 0;
                }
                else
                {
                    index = Notifications.Count - 1;
                }
                buffer.Insert(0,Notifications[index]);
                Notifications.RemoveAt(index);
                InvalidateMeasure();
            }
            return ret;
        }
