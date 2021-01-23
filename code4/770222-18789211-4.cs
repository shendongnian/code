    [HttpPost]
    public ActionResult Create(MyObjectModel o)
    {
    	try
    	{
    			if (ModelState.IsValid)
    			{
    
    			    
    				return RedirectToAction("ObjectCreated", new { id = o.objectId });
    			}
    			else
    			{
    				var errors = ModelState
    					.Where(x => x.Value.Errors.Count > 0)
    					.Select(x => new { x.Key, x.Value.Errors })
    					.ToArray();
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		Response.Write(ex.InnerException.Message);
    	}
    	//If we get here it means the model is not valid, We're in trouble
    	//then redisplay the view repopulate the dropdown
    	var ObjectResultList = _system.GetAllObjects(objectId);
    	var ObjectSelectList = new SelectList(ObjectResultList, "id", "value");
    	ViewBag.ObjectList = ObjectSelectList;
    
    
    	return View(o);
    }
