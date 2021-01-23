               if (size < 1024)
                {
                    return string.Format("{0:#} bytes", size.Value);
                }
                else if(size < 1048576)
                {
                    return String.Format("{0:#} KB", (size.Value / 1024));
                }
                else if(size < 1073741824)
                {
                    return String.Format("{0:#} MB", ((size.Value / 1024) / 1024));
                }
                else
                {
                    return String.Format("{0:#} GB", (((size.Value / 1024) / 1024) / 1024));
                }
