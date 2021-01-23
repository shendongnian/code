    myextensions.GetEnumValues<cardCreate>()
                .Select (ceEnum => new
                            {
                                Original   = ceEnum,
                                IndexValue = (int)ceEnum,
                                Text       = ceEnum.GetAttributeDescription()
                            })
