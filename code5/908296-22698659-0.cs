    public class MaterialXMLComparer : IEqualityComparer<MaterialXML>
        {
            private IEqualityComparer<AlternateUnitXML> _alternateComparer;
            private IEqualityComparer<MaterialsPatnerXMLforMaterial> _matPartnerComparer;
    
            public MaterialXMLComparer(IEqualityComparer<AlternateUnitXML> alternateComparer,IEqualityComparer<MaterialsPatnerXMLforMaterial> matPartnerComparer)
            {
                _alternateComparer = alternateComparer;
                _matPartnerComparer = matPartnerComparer;
            }
            public bool Equals(MaterialXML x, MaterialXML y)
            {
                bool firstLevelEqual = (x.Reference == y.Reference) &&
                        (x.MeasurementUnitCode == y.MeasurementUnitCode) &&
                        (x.Denomination == y.Denomination) &&
                        (x.Weight == y.Weight) &&
                        (x.PieceType == y.PieceType) &&
                        (x.Type == y.Type) &&
                        (x.Position == y.Position);
    
                bool secondLevelEqual=false;
                if (firstLevelEqual)
                {
                    if (x.AlternateUnits.SequenceEqual(y.AlternateUnits, _alternateComparer))
                    {
                        secondLevelEqual= true;
                    }
                }
    
                if (secondLevelEqual)
                {
                    if (x.MaterialsPartner.SequenceEqual(y.MaterialsPartner, _matPartnerComparer))
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
