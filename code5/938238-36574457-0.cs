    IEnumerable<SelectListItem> itemEtatRenseig = listeEtatRens.Select(c => new SelectListItem
            {
                    Value = c.EtatReseigne,
                    Text = c.EtatReseigne,
            });
            VewBag.EtatRenseign = new SelectList(itemEtatRenseig, "Value", "Text", Rapport.RapportList.FirstOrDefault().EtatReseigne); 
