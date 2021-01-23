    foreach (var item1 in ocChoicesinItem.ToList())
        {
            foreach (var item2 in temp.ItemsInInvoiceChoices)
            {
                if (item1.ChoicesId == item2.ChoicesId)
                    ocChoicesinItem.Remove(item1);
            }
        }
