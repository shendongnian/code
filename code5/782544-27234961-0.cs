    void UpdateSPListItem(SPListItem item, Model pageItem)
        {
            SetValueInternalName(item, "ArticleByLine", pageItem.ArticleByLine);
            SetValueInternalName(item, "Comments", pageItem.Comments);
        }
        void SetValueInternalName(SPListItem item, string fieldInternalName, string value)
        {
            SPField field = item.Fields.GetFieldByInternalName(fieldInternalName);
            item[field.Id] = value;
        }
