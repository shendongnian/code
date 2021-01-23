    void OnMouseDown()
            {
                    if(state == State.water)
                    {
                            errorHandler.sendError("You can't click on that");
                    }
     
                    if(state == State.ice)
                    {
                            towerMenu.ShowMenu(camera.WorldToViewportPoint(this.transform.position));
                    }
            }
