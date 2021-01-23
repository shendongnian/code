                int i = 0;
                foreach (RoomInfo game in PhotonNetwork.GetRoomList())
                {
                    if (GUI.Button(new Rect(5, (40 * (i + 2)) + 10, Screen.width - 10, 40), "Join" + game.name, _skin.button))
                    {
                        PhotonNetwork.JoinRoom(game.name);
                    }
                    i++;
                }
