        [Test] public void Issue_681__Navigating_libraries_views_folders__Clicking_the_icon_doesnt_work()
        {
            var tmWebServices  = new TM_WebServices();            
            Func<string, string> clickOnNodeUsingJQuerySelector = 
	            (jQuerySelector)=>
		            {			
			            ie.invokeEval("TM.Gui.selectedGuidanceTitle=undefined");
			            ie.invokeEval("$('#{0}').click()".format(jQuerySelector));
			            ie.waitForJsVariable("TM.Gui.selectedGuidanceTitle");
			            return ie.getJsObject<string>("TM.Gui.selectedGuidanceTitle");
		            };
            if (tmProxy.libraries().notEmpty())
            {
	            "Ensuring the the only library that is there is the TM Documentation".info();
	            foreach(var library in tmProxy.libraries())
		            if(library.Caption != "TM Documentation") 
		            {
			            "deleting library: {0}".debug(library.Caption);
			            tmProxy.library_Delete(library.Caption);
		            }	          
            }   
            UserRole.Admin.assert();
            tmProxy.library_Install_Lib_Docs();
	        tmProxy.cache_Reload__Data();
            tmProxy.show_ContentToAnonymousUsers(true);
            ieTeamMentor.page_Home();        
            //tmWebServices.script_Me_WaitForClose();;
            //ieTeamMentor.script_IE_WaitForComplete();
            ie.waitForJsVariable("TM.Gui.selectedGuidanceTitle");            
            var _jsTree =  tmWebServices.JsTreeWithFolders();
            var viewNodes = _jsTree.data[0].children;				// hard coding to the first library
            var view1_Id    = viewNodes[0].attr.id;
            var view5_Id    = viewNodes[4].attr.id;
            var click_View_1_Using_A    = clickOnNodeUsingJQuerySelector(view1_Id + " a"  );
            var click_View_5_Using_A    = clickOnNodeUsingJQuerySelector(view5_Id + " a"  );
            var click_View_1_Using_Icon = clickOnNodeUsingJQuerySelector(view1_Id + " ins"  );
            var click_View_5_Using_Icon = clickOnNodeUsingJQuerySelector(view5_Id + " ins"  );
            (click_View_1_Using_A != click_View_5_Using_A   ).assert_True(); 
            
            (click_View_5_Using_A == click_View_1_Using_Icon).assert_False(); // (Issue 681) this was true since the view was not updating
            (click_View_5_Using_A == click_View_5_Using_Icon).assert_True(); 
        }
