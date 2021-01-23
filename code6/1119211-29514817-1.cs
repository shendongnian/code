        private string cameraURL;
    
        private bool recModeActive;
        public void ControlCamera(string cameraResp)
        {
            cameraURL = string.Format("{0}/{1}", GetCameraURL(cameraResp), GetActionType(cameraResp));
        }
        private string CameraRequest(string cameraUrl, string cameraRequest)
        {
            Uri urlURI = new Uri(cameraURL);
            HttpWebRequest cameraReq = (HttpWebRequest)WebRequest.Create(cameraURL);
            cameraReq.Method = "POST";
            cameraReq.AllowWriteStreamBuffering = false;
            cameraReq.ContentType = "application/json; charset=utf-8";
            cameraReq.Accept = "Accept-application/json";
            cameraReq.ContentLength = cameraRequest.Length;
            using (var cameraWrite = new StreamWriter(cameraReq.GetRequestStream()))
            {
                cameraWrite.Write(cameraRequest);
            }
            var cameraResp = (HttpWebResponse)cameraReq.GetResponse();
            Stream cameraStream = cameraResp.GetResponseStream();
            StreamReader cameraRead = new StreamReader(cameraStream);
            string readCamera = cameraRead.ReadToEnd();
            
            return readCamera;
        }
        public string GetCameraURL(string cameraResp)
        {
            string[] cameraXML = cameraResp.Split('\n');
            string cameraURL = "";
            foreach (string cameraString in cameraXML)
            {
                string getCameraURL = "";
                if (cameraString.Contains("<av:X_ScalarWebAPI_ActionList_URL>"))
                {
                    getCameraURL = cameraString.Substring(cameraString.IndexOf('>') + 1);
                    cameraURL = getCameraURL.Substring(0, getCameraURL.IndexOf('<'));
                }
            }
            return cameraURL;
        }
        public string GetActionType(string cameraResp)
        {
            string[] cameraXML = cameraResp.Split('\n');
            string actionType = "";
            foreach (string cameraString in cameraXML)
            {
                string getType = "";
                if (cameraString.Contains("<av:X_ScalarWebAPI_ServiceType>"))
                {
                    getType = cameraString.Substring(cameraString.IndexOf('>') + 1);
                    actionType = getType.Substring(0, getType.IndexOf('<'));
                    if (actionType == "camera")
                    {
                        break;
                    }
                }
            }
            return actionType;
        }
        public string StartRecMode()
        {
            string startRecMode = JsonConvert.SerializeObject(new Camera.CameraSetup
            {
                method = "startRecMode",
                @params = new List<string> { },
                id = 1,
                version = "1.0"
            });
            recModeActive = true;
            return CameraRequest(cameraURL, startRecMode);
        }
        public string TriggerCamera()
        {
            string _triggerCamera = JsonConvert.SerializeObject(new Camera.StillCapture
            {
                method = "actTakePicture",
                @params = new List<string> { },
                id = 1,
                version = "1.0"
            });
            return CameraRequest(cameraURL, _triggerCamera);
        }
        public string EchoRequest()
        {
            string _echoRequest = JsonConvert.SerializeObject(new Camera.TestCameraComm
            {
                method = "getEvent",
                @params = new List<bool> { true },
                id = 1,
                version = "1.0"
            });
            return CameraRequest(cameraURL, _echoRequest);
        }
        public string StopRecMode()
        {
            string stopRecMode = JsonConvert.SerializeObject(new Camera.CameraSetup
            {
                method = "stopRecMode",
                @params = new List<string> { },
                id = 1,
                version = "1.0"
            });
            recModeActive = false;
            return CameraRequest(cameraURL, stopRecMode);
        }
        public string SetImageQuality()
        {
            string qualityReq = JsonConvert.SerializeObject(new Camera.CameraSetup
            {
                method = "setStillSize",
                @params = new List<string> { "4:3", "20M"},
                id = 1,
                version = "1.0"
            });
            recModeActive = false;
            return CameraRequest(cameraURL, qualityReq);
        }`
