        public class MaterialXMLComparer : IEqualityComparer<MaterialXML>
        {
            private  IEqualityComparer<AlternateUnitXML> _alternateComparer;
            public MaterialXMLComparer(IEqualityComparer<AlternateUnitXML> alternateComparer)
            {
                _alternateComparer = alternateComparer;
            }
            public bool Equals(MaterialXML x, MaterialXML y)
            {
                bool firstLevelEqual = (x.Reference == y.Reference) &&
                    (x.MeasurementUnitCode == y.MeasurementUnitCode);
                if (firstLevelEqual)
                {
                    if (x.AlternateUnits.SequenceEqual(y.AlternateUnits, _alternateComparer))
                    {
                        return true;
                    }
                }
                return false;
            }
            public int GetHashCode(MaterialXML obj)
            {
                return obj.Reference.GetHashCode();
            }
        }
        public class AlternateUnitXMLComparer : IEqualityComparer<AlternateUnitXML>
        {
            public bool Equals(AlternateUnitXML x, AlternateUnitXML y)
            {
                return (x.Code == y.Code) &&
                    (x.PrimaryQuantity == y.PrimaryQuantity) &&
                    (x.SecondaryQuantity == y.SecondaryQuantity);
            }
            public int GetHashCode(AlternateUnitXML obj)
            {
                return obj.Code.GetHashCode();
            }
        }
