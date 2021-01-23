    IList<string> selectedUsers = ... //The list of selected usernames
    ViewBag.Json = JsonConvert.SerializeObject(new
                {
                    Utilizadores = db.Utilizador.Select(u => new { Id = u.Id, Nome = u.Nome, Info = u.NumMecanografico, Selected = selectedUsers.Contains(u.Nome) })
                });
