        private static object SearchPosition(List<TagType<object>> tagList, string fieldTag)
        {
            var i = tagList.FindIndex(x => x.FieldTag == "PT");
            if (i >= 0 && i < tagList.Count)
            {
                return tagList[i + 1].Position;
            }
        }
