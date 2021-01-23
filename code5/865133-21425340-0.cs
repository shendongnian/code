                if (!string.IsNullOrEmpty(mappedProperty))
                {
                    foreach (string item in list)
                    {
                        if (item != mappedProperty)
                        {
                            isValid = false;
                        }
                        else
                        {
                            isValid = true;
                            break;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }
