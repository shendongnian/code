    private TaxonomyFieldValueCollection TaxonomyFieldToCollection(object item)
        {
            if (item != null)
            {
                TaxonomyFieldValue temp = item as TaxonomyFieldValue;
                TaxonomyFieldValueCollection tempCol = new TaxonomyFieldValueCollection(temp.ValidatedString);
                return tempCol;
            }
            else
            {
                TaxonomyFieldValueCollection tempCol = new TaxonomyFieldValueCollection(string.Empty);
                tempCol.Clear();
                return tempCol;
            }
        }
