    foreach (ClasaAutor autor in listaAutoriPublicatie)
    {
        foreach (ListItem item in list.Items)
        {
            if (item.Value == autor.GuidAutor.ToString())
                item.Selected = true;
        }
    }
