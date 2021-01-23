        internal void USBEventArrived_Creation(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("USB PLUGGED IN!");
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                
                if (property.Name == "Name")
                    Console.WriteLine(property.Name + " = " + property.Value);
            }
        }
