    var type = Type.GetType(nameParts[0] + ", " + nameParts[1]);
                if (type == null)
                {
                    throw new EasyNetQException(
                        "Cannot find type {0}",
                        typeName);
                }
