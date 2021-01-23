            ManagementScope scope = new ManagementScope(@"\\" + strComputer + @"\root\cimv2");
            SelectQuery query = new SelectQuery("Select * From Win32_Service");
            var typeDescriptors = new ObservableCollection<ManagementObjectTypeDescriptor>();
            using (var searcher = new ManagementObjectSearcher(scope, query))
            {
                using (var managementObjects = searcher.Get())
                {
                    foreach (ManagementBaseObject managementObject in managementObjects)
                    {
                        using (managementObject)
                        {
                            typeDescriptors.Add(new ManagementObjectTypeDescriptor(managementObject));
                        }
                    }
                }
            }
            dgResults.ItemsSource = new ArrayList(typeDescriptors);
