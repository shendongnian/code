    public ActionResult Index()
    {
        ViewBag.Message = "Academia Page";
        AcademiaViewModel viewmodel = new AcademiaViewModel();
        viewmodel.CwcConteudos = db.CWC_CONTEUDOS.Include(c => c.CWC_PAGINAS)
                             .Where(c => c.CWC_PAGINAS.id_page == 1);
        viewmodel.FicheiroconteudosList = (from c in db.CWC_FILESCONTEUDOS
                    join d in db.CWC_FICHEIROS on c.idfile equals d.id_file
                    join e in db.CWC_TIPOSFICHEIROS on d.idfiletype equals e.id_tpfile
                    join f in db.CWC_EXTENSOESFILES on e.id_tpfile equals f.idtpdoc
                    select (new Ficheiroconteudos
                          { 
                              IdFilic = d.id_file,
                              filenamec = d.filename,
                              fileurlc = d.fileurl,
                              fileimg = e.tipoimg,
                              fileextc = f.extensao
                          })).ToList();
        return View(viewmodel);
    }
    
