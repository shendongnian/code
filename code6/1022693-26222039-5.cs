        [CustomAction]
        public static ActionResult CheckSqlSessionState(Session session)
        {
            try
            {
                session.SendMessage(InstallMessage.Info, "Check Sql Session State");
                return ActionResult.Success;
            }
            catch (Exception exception)
            {
                session.SendMessage(InstallMessage.Error,
                    string.Format("Error during the cheking sesssion state. {0}", exception.Message));
                return ActionResult.Failure;
            }
        }
