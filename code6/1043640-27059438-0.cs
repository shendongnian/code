     m_BotInvaderHitBox = new Rectangle(m_BotInvaderCurrentFrame * m_BotInvaderFrameWidth, 0, m_BotInvaderFrameWidth, m_BotInvaderFrameHeight);
                m_BotInvaderOrigin = new Vector2(m_BotInvaderHitBox.X / 2, m_BotInvaderHitBox.Y / 2);
                m_Timer += (float)gameTime.ElapsedGameTime.Milliseconds;
                if (m_Timer > m_Interval)
                {
                    m_BotInvaderCurrentFrame++;
                    m_Timer = 0f;
                }
                if (m_BotInvaderCurrentFrame == 2)
                {
                    m_BotInvaderCurrentFrame = 0;
                }
                m_BotInvaderHitBox = new Rectangle(m_BotInvaderCurrentFrame * m_BotInvaderFrameWidth, 0, m_BotInvaderFrameWidth, m_BotInvaderFrameHeight);
                m_BotInvaderOrigin = new Vector2(m_BotInvaderHitBox.Width / 2, m_BotInvaderHitBox.Height / 2);
                int m_RightSide = 800;
                int m_LeftSide = 0;
                for (int r = 0; r < m_InvaderRows; r++)
                {
                    for (int c = 0; c < m_InvaderCollumns; c++)
                    {
                        if (m_BotInvadersDirection.Equals ("RIGHT"))
                        {
                            m_BotInvadersRect[r, c].X = m_BotInvadersRect[r, c].X + 1;
                        }
                        if (m_BotInvadersDirection.Equals("LEFT"))
                        {
                            m_BotInvadersRect[r, c].X = m_BotInvadersRect[r, c].X - 1;
                        }
                    }
                }
                String m_BotInvadersChangeDirection = "N";
                for (int r = 0; r < m_InvaderRows; r++)
                {
                    for (int c = 0; c < m_InvaderCollumns; c++)
                    {
                        if (m_BotInvadersRect[r, c].X + m_BotInvadersRect[r, c].Width > m_RightSide)
                        {
                            m_BotInvadersDirection = "LEFT";
                            m_BotInvadersChangeDirection = "Y";
                        }
                        if (m_BotInvadersRect[r, c].X < m_LeftSide)
                        {
                            m_BotInvadersDirection = "RIGHT";
                            m_BotInvadersChangeDirection = "Y";
                        }
                    }
                    if (m_BotInvadersChangeDirection.Equals("Y"))
                    {
                            for (int c = 0; c < m_InvaderCollumns; c++)
                            {
                                m_BotInvadersRect[r, c].Y = m_BotInvadersRect[r, c].Y + 3;
                            }
                    }
                }
